using System.Security.Claims;
using BusinessApp.Entities;
using BusinessApp.Repositories.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BusinessApp.Controllers
{
  [Authorize]
  public class ProfileController : Controller
  {
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IApplicationRepository _applicationRepository;
    private readonly ISavedJobRepository _savedJobRepository;
    private readonly IBlogRepository _blogRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IEmployerRepository _employerRepository;

    public ProfileController(IUserRepository userRepository, IRoleRepository roleRepository, IApplicationRepository applicationRepository, ISavedJobRepository savedJobRepository, IBlogRepository blogRepository, ICategoryRepository categoryRepository, IEmployerRepository employerRepository)
    {
      _userRepository = userRepository;
      _roleRepository = roleRepository;
      _applicationRepository = applicationRepository;
      _savedJobRepository = savedJobRepository;
      _blogRepository = blogRepository;
      _categoryRepository = categoryRepository;
      _employerRepository = employerRepository;
    }

    public async Task<IActionResult> Index()
    {
      var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
      if (userId is null)
      {
        return Unauthorized();
      }
      var user = await _userRepository.GetByIdUserAsync(int.Parse(userId));


      return View(user);
    }

    public async Task<IActionResult> MyJobs()
    {
      var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
      if (userId is null)
      {
        return Unauthorized();
      }
      var myJobs = await _applicationRepository.GetAllApplicationsAsync(int.Parse(userId));
      return View(myJobs);
    }

    public async Task<IActionResult> SavedJobs()
    {
      var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
      var savedIds = new List<int>();

      if (userId is not null)
      {
        savedIds = await _applicationRepository.GetAllUserAndJobAsync(int.Parse(userId));
      }

      ViewBag.SavedIds = savedIds;

      var savedJobs = await _savedJobRepository.GetAllSavedJobsAsync(int.Parse(userId));
      return View(savedJobs);
    }

    public async Task<IActionResult> MyBlogs()
    {
      var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
      if (userId is null)
      {
        return Unauthorized();
      }

      var myBlogs = await _blogRepository.GetAllUserAndBlogAsync(int.Parse(userId));
      return View(myBlogs);
    }

    [HttpGet]
    public async Task<IActionResult> BlogCreate()
    {
      var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
      if (userId is null)
      {
        return Unauthorized();
      }
      ViewBag.CurrentUserId = userId;
      ViewBag.Categories = new SelectList(await _categoryRepository.GetAllAsync(), "Id", "Name");
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> BlogCreate(Blog blog)
    {
      await _blogRepository.AddAsync(blog);
      return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> BlogEdit(int id)
    {
      var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
      if (userId is null)
      {
        return Unauthorized();
      }
      ViewBag.CurrentUserId = userId;
      ViewBag.Categories = new SelectList(await _categoryRepository.GetAllAsync(), "Id", "Name");
      var blog = await _blogRepository.GetByIdBlogAsync(id);
      return View(blog);
    }

    [HttpPost]
    public async Task<IActionResult> BlogEdit(Blog blog)
    {
      await _blogRepository.UpdateBlogAsync(blog);
      return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> BlogDelete(int id)
    {
      await _blogRepository.DeleteAsync(id);
      return RedirectToAction("MyBlogs");
    }

    [HttpGet]
    public async Task<IActionResult> MyCompany()
    {
      var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
      if (userId is null)
      {
        return Unauthorized();
      }

      var myCompanys = await _employerRepository.GetAllEmployersUserAsync(int.Parse(userId));
      return View(myCompanys);
    }
    [HttpGet]
    public async Task<IActionResult> MyJob()
    {
      return View();
    }
  }
}