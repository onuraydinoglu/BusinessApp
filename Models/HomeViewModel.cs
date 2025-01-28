using BusinessApp.Entities;

namespace BusinessApp.Models
{
    public class HomeViewModel
    {
        public IEnumerable<Job> Jobs { get; set; } = null!;
        public IEnumerable<Blog> Blogs { get; set; } = null!;
    }
}