using ASP.NETCoreWebAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASP.NETCoreWebAPI.EntityConfigurations
{
    public class TagConfiguration: IEntityTypeConfiguration<Tag>
  {
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
      builder.HasData(
        new Tag() { Id = 1, Name = "C#"},
        new Tag() { Id = 2, Name = "Angular"},
        new Tag() { Id = 3, Name = "JavaScript"},
        new Tag() { Id = 4, Name = "NodeJs"},
        new Tag() { Id = 5, Name = "OOP"},
        new Tag() { Id = 6, Name = "Linq"}
      );
    }
  }
}