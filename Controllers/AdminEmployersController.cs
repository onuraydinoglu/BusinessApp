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

    public AdminEmployersController(IEmployerRepository employerRepository)
    {
      _employerRepository = employerRepository;
    }

    public async Task<IActionResult> Index()
    {
      var employers = await _employerRepository.GetAllAsync();
      return View(employers);
    }


    [HttpGet]
    public async Task<IActionResult> Create()
    {
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