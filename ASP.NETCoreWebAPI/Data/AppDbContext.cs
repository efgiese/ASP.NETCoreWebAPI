using ASP.NETCoreWebAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace ASP.NETCoreWebAPI.Data
{
    public class AppDbContext : DbContext
    {
      public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

      public DbSet<Author> Authors { get; set; }

    }
}