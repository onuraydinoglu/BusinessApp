using BusinessApp.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BusinessApp.Models
{
  public class BlogViewModel
  {
    public IEnumerable<Blog> Blogs { get; set; } = null!;
    public Blog? Blog { get; set; }
  }
}