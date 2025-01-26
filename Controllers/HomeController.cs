using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BusinessApp.Models;
using BusinessApp.Repositories.Abstracts;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace BusinessApp.Controllers;

public class HomeController : Controller
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IJobRepository _jobRepository;
    public HomeController(ICategoryRepository categoryRepository, IJobRepository jobRepository)
    {
        _categoryRepository = categoryRepository;
        _jobRepository = jobRepository;
    }



    public async Task<IActionResult> Index()
    {

        var jobs = await _jobRepository.GetAllJobsAsync();
        var modelView = new JobViewModel
        {
            Jobs = jobs
        };
        return View(modelView);
    }
}
