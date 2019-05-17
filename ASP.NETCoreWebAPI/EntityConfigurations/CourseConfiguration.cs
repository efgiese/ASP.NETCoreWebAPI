using ASP.NETCoreWebAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASP.NETCoreWebAPI.EntityConfigurations
{
  public class CourseConfiguration : IEntityTypeConfiguration<Course>
  {
    public void Configure(EntityTypeBuilder<Course> builder)
    {
      builder.HasOne<CourseCover>(c => c.Cover)
        .WithOne(cc => cc.Course)
        .HasForeignKey<CourseCover>(cc => cc.CoverOfCourseId);

      builder.HasOne(c => c.Author)
        .WithMany(a => a.Courses)
        .OnDelete(DeleteBehavior.Restrict);

      builder.Property(c => c.Description)
        .IsRequired()
        .HasMaxLength(2000);

      builder.Property(c => c.Name)
        .IsRequired()
        .HasMaxLength(255);

      builder.HasData(
        new
        {
          Id = 1,
          AuthorId = 1,
          Name = "C# Basics",
          FullPrice = 49F,
          Description = "Description for C# Basics",
          Level = 1
        },
        new
        {
          Id = 2,
          AuthorId = 1,
          Name = "C# Intermediate",
          FullPrice = 49F,
          Description = "Description for C# Intermediate",
          Level = 2
        },
        new
        {
          Id = 3,
          AuthorId = 1,
          Name = "C# Advanced",
          FullPrice = 69F,
          Description = "Description for C# Advanced",
          Level = 3
        },
        new
        {
          Id = 4,
          AuthorId = 2,
          Name = "Javascript: Understanding the Weird Parts",
          FullPrice = 149F,
          Description = "Description for Javascript",
          Level = 2
        },
        new
        {
          Id = 5,
          AuthorId = 2,
          Name = "Learn and Understand AngularJS",
          FullPrice = 99F,
          Description = "Description for AngularJS",
          Level = 2
        },
        new
        {
          Id = 6,
          AuthorId = 2,
          Name = "Learn and Understand NodeJS",
          FullPrice = 149F,
          Description = "Description for NodeJS",
          Level = 2
        },
        new
        {
          Id = 7,
          AuthorId = 3,
          Name = "Programming for Complete Beginners",
          FullPrice = 45F,
          Description = "Description for Programming for Beginners",
          Level = 1
        },
        new
        {
          Id = 8,
          AuthorId = 4,
          Name = "A 16 Hour C# Course with Visual Studio 2013",
          FullPrice = 150F,
          Description = "Description 16 Hour Course",
          Level = 1
        },
        new
        {
          Id = 9,
          AuthorId = 4,
          Name = "Learn JavaScript Through Visual Studio 2013",
          FullPrice = 20F,
          Description = "Description Learn Javascript",
          Level = 1
        }
      );
    }
  }
}