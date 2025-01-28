using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BusinessApp.Models;
using BusinessApp.Repositories.Abstracts;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace BusinessApp.Controllers;

public class HomeController : Controller
{
    private readonly IBlogRepository _blogRepository;
    private readonly IJobRepository _jobRepository;
    public HomeController(IJobRepository jobRepository, IBlogRepository blogRepository)
    {
        _jobRepository = jobRepository;
        _blogRepository = blogRepository;
    }

    public async Task<IActionResult> Index()
    {
        var jobs = await _jobRepository.GetAllJobsAsync();
        var blogs = await _blogRepository.GetAllBlogsAsync();
        var modelView = new HomeViewModel
        {
            Jobs = jobs,
            Blogs = blogs
        };
        return View(modelView);
    }
}
