using Microsoft.EntityFrameworkCore;
using WebApi.Entities.Models;

namespace WebApi.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Meal> Meals { get; set; }
        public DbSet<OrderInformation> OrderInformation { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<UserLogin> UserLogin { get; set; }
    }
}
