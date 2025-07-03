using KvalikApi.Model;
using Microsoft.EntityFrameworkCore;

namespace KvalikApi.Context
{
    public class ContextDb : DbContext
    {
        public ContextDb(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Delivery> Delivery { get; set; }
        public DbSet<DeliveryProduct> DeliveryProduct { get; set; }
        public DbSet<Receipt> Receipt { get; set; }
        public DbSet<ReturnProduct> ReturnProduct { get; set; }
        public DbSet<Car> Car { get; set; }
        public DbSet<CarService> CarService { get; set; }
        public DbSet<UserChat> UserChat { get; set; }
        public DbSet<UserChatMessage> UserChatMessage { get; set; }

    }
}
