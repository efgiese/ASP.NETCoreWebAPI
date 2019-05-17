using ASP.NETCoreWebAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASP.NETCoreWebAPI.EntityConfigurations
{
  public class AuthorConfiguration : IEntityTypeConfiguration<Author>
  {
    public void Configure(EntityTypeBuilder<Author> builder)
    {
      builder.HasData(
        new Author()
        {
          Id = 1,
          Name = "Mosh Hamedani"
        },
        new Author()
        {
          Id = 2,
          Name = "Anthony Alicea"
        },
        new Author()
        {
          Id = 3,
          Name = "Eric Wise"
        },
        new Author()
        {
          Id = 4,
          Name = "Tom Owsiak"
        },
        new Author()
        {
          Id = 5,
          Name = "John Smith"
        }
      );
    }
  }
}
