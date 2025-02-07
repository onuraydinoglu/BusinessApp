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

    public ProfileController(IUserRepository userRepository, IRoleRepository roleRepository, IApplicationRepository applicationRepository, ISavedJobRepository savedJobRepository, IBlogRepository blogRepository)
    {
      _userRepository = userRepository;
      _roleRepository = roleRepository;
      _applicationRepository = applicationRepository;
      _savedJobRepository = savedJobRepository;
      _blogRepository = blogRepository;
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

  }
}