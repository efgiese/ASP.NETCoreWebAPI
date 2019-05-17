using ASP.NETCoreWebAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASP.NETCoreWebAPI.EntityConfigurations
{
    public class CourseTagConfiguration : IEntityTypeConfiguration<CourseTag>
  {
    public void Configure(EntityTypeBuilder<CourseTag> builder)
    {
      builder.HasKey(ct => new { ct.CourseId, ct.TagId });

      builder.HasOne(ct => ct.Course)
        .WithMany(c => c.CourseTags)
        .HasForeignKey(ct => ct.CourseId);

      builder.HasOne(ct => ct.Tag)
        .WithMany(t => t.CourseTags)
        .HasForeignKey(ct => ct.TagId);

      builder.HasData(
        new CourseTag() { CourseId = 1, TagId = 1 },
        new CourseTag() { CourseId = 2, TagId = 1 },
        new CourseTag() { CourseId = 2, TagId = 5 },
        new CourseTag() { CourseId = 3, TagId = 1 },
        new CourseTag() { CourseId = 4, TagId = 3 },
        new CourseTag() { CourseId = 5, TagId = 2 },
        new CourseTag() { CourseId = 6, TagId = 4 },
        new CourseTag() { CourseId = 7, TagId = 1 },
        new CourseTag() { CourseId = 8, TagId = 1 },
        new CourseTag() { CourseId = 9, TagId = 3 }
      );
    }
  }
}