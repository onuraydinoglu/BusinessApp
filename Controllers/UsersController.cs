using BusinessApp.Entities;
using BusinessApp.Repositories.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BusinessApp.Controllers
{
  public class UsersController : Controller
  {
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;

    public UsersController(IUserRepository userRepository, IRoleRepository roleRepository)
    {
      _userRepository = userRepository;
      _roleRepository = roleRepository;
    }

    public async Task<IActionResult> Index()
    {
      var users = await _userRepository.GetAllAsync();
      return View(users);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
      ViewBag.Roles = new SelectList(await _roleRepository.GetAllAsync(), "Id", "Name");
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(User user)
    {
      await _userRepository.AddAsync(user);
      return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
      await _userRepository.DeleteAsync(id);
      return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
      var usr = await _userRepository.GetByIdAsync(id);
      return View(usr);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(User user)
    {
      await _userRepository.UpdateUserAsync(user);
      return RedirectToAction("Index");
    }
  }
}