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

    public ProfileController(IUserRepository userRepository, IRoleRepository roleRepository)
    {
      _userRepository = userRepository;
      _roleRepository = roleRepository;
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


  }
}