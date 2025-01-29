using System.Threading.Tasks;
using BusinessApp.Entities;
using BusinessApp.Models;
using BusinessApp.Repositories.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BusinessApp.Controllers
{
  [Authorize(Roles = "Admin")]
  public class AdminUsersController : Controller
  {
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;

    public AdminUsersController(IUserRepository userRepository, IRoleRepository roleRepository)
    {
      _userRepository = userRepository;
      _roleRepository = roleRepository;
    }

    public async Task<IActionResult> Index()
    {
      var users = await _userRepository.GetAllUserAsync();
      return View(users);
    }


    [HttpGet]
    public async Task<IActionResult> Create()
    {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(User user)
    {
      await _userRepository.AddAsync(user);
      return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
      ViewBag.Roles = new SelectList(await _roleRepository.GetAllAsync(), "Id", "Name");
      var user = await _userRepository.GetByIdUserAsync(id);
      return View(user);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(User user)
    {
      await _userRepository.UpdateUserAsync(user);
      return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
      await _userRepository.DeleteAsync(id);
      return RedirectToAction("Index");
    }

  }
}