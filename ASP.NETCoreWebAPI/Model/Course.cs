using System.Collections.Generic;

namespace ASP.NETCoreWebAPI.Model
{
  public class Course
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Level { get; set; }
    public float FullPrice { get; set; }
    public Author Author { get; set; }
    public ICollection<CourseTag> CourseTags { get; set; }
    public CourseCover Cover { get; set; }
  }
}