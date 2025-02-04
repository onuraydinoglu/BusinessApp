using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BusinessApp.Models;
using BusinessApp.Repositories.Abstracts;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using System.Security.Claims;

namespace BusinessApp.Controllers;

public class HomeController : Controller
{
    private readonly IUserRepository _userRepository;
    private readonly IBlogRepository _blogRepository;
    private readonly IJobRepository _jobRepository;
    private readonly ISavedJobRepository _savedJobRepository;
    public HomeController(IUserRepository userRepository, IJobRepository jobRepository, IBlogRepository blogRepository, ISavedJobRepository savedJobRepository)
    {
        _userRepository = userRepository;
        _jobRepository = jobRepository;
        _blogRepository = blogRepository;
        _savedJobRepository = savedJobRepository;
    }

    public async Task<IActionResult> Index()
    {
        var jobs = await _jobRepository.GetAllJobsAsync();
        var blogs = await _blogRepository.GetAllBlogsAsync();

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var savedJobIds = new List<int>();

        if (userId != null)
        {
            var savedJobs = await _savedJobRepository.GetAllSavedJobsAsync(int.Parse(userId));
            savedJobIds = savedJobs.Select(s => s.JobId).ToList();
        }

        ViewBag.SavedJobIds = savedJobIds; // Kullanıcının kaydettiği iş ilanları ID'leri

        var modelView = new HomeViewModel
        {
            Jobs = jobs,
            Blogs = blogs
        };
        return View(modelView);
    }
}
