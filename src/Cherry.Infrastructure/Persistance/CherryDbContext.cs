using Cherry.Domain.Common;
using Cherry.Domain.FoodAggregate;
using Cherry.Domain.IdentityAggregate;
using Cherry.Domain.OrderAggregate;
using Cherry.Infrastructure.Persistance.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Cherry.Infrastructure.Persistance
{
    public class CherryDbContext : IdentityDbContext<ApplicationUser>
    {
        public static readonly ILoggerFactory _loggerFactory
            = LoggerFactory.Create(builder =>
            {
                builder.AddDebug();
            });
        public CherryDbContext(DbContextOptions<CherryDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(_loggerFactory);
        }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RestaurantConfiguration());
            modelBuilder.ApplyConfiguration(new FoodConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}