using ASP.NETCoreWebAPI.Model;
using ASP.NETCoreWebAPI.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace ASP.NETCoreWebAPI.Data
{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Author> Authors { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<CourseTag> CourseTags { get; set; }
    public DbSet<CourseCover> CourseCovers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfiguration(new CourseTagConfiguration());
      modelBuilder.ApplyConfiguration(new TagConfiguration());
      modelBuilder.ApplyConfiguration(new AuthorConfiguration());
      modelBuilder.ApplyConfiguration(new CourseConfiguration());
    }

  }
}