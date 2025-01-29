using BusinessApp.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BusinessApp.Models
{
    public class JobViewModel
    {
        public IEnumerable<Job> Jobs { get; set; } = null!;
        public Job? Job { get; set; }
        public User? User { get; set; }
    }
}