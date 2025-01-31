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

    public ProfileController(IUserRepository userRepository, IRoleRepository roleRepository, IApplicationRepository applicationRepository)
    {
      _userRepository = userRepository;
      _roleRepository = roleRepository;
      _applicationRepository = applicationRepository;
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
  }
}