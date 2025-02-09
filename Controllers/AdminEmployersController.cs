using System.Security.Claims;
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
  public class AdminEmployersController : Controller
  {
    private readonly IEmployerRepository _employerRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUserRepository _userRepository;

    public AdminEmployersController(IEmployerRepository employerRepository, ICategoryRepository categoryRepository, IUserRepository userRepository)
    {
      _employerRepository = employerRepository;
      _categoryRepository = categoryRepository;
      _userRepository = userRepository;
    }

    public async Task<IActionResult> Index()
    {
      var employers = await _employerRepository.GetAllEmployersAsync();
      return View(employers);
    }


    [HttpGet]
    public async Task<IActionResult> Create()
    {
      ViewBag.Users = new SelectList(await _userRepository.GetAllAsync(), "Id", "FullName");
      ViewBag.Categories = new SelectList(await _categoryRepository.GetAllAsync(), "Id", "Name");
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Employer employer)
    {
      await _employerRepository.AddAsync(employer);
      return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
      ViewBag.Users = new SelectList(await _userRepository.GetAllAsync(), "Id", "FullName");
      ViewBag.Categories = new SelectList(await _categoryRepository.GetAllAsync(), "Id", "Name");

      var employer = await _employerRepository.GetByIdAsync(id);
      return View(employer);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Employer employer)
    {
      await _employerRepository.UpdateEmployerAsync(employer);
      return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
      await _employerRepository.DeleteAsync(id);
      return RedirectToAction("Index");
    }

  }
}