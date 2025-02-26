using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace WebApi.Data
{
    public class DbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseSqlServer("Data Source=(localdb)\\Local;Initial Catalog=Restaurant;Integrated Security=True;Trust Server Certificate=True;");

            return new AppDbContext(builder.Options);
        }
    }
}
