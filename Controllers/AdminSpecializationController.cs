using BusinessApp.Entities;
using BusinessApp.Repositories.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BusinessApp.Controllers
{
  public class AdminSpecializationController : Controller
  {
    private readonly ISpecializationRepository _specializationRepository;
    private readonly ICategoryRepository _categoryRepository;

    public AdminSpecializationController(ISpecializationRepository specializationRepository, ICategoryRepository categoryRepository)
    {
      _specializationRepository = specializationRepository;
      _categoryRepository = categoryRepository;
    }

    public async Task<IActionResult> Index()
    {
      var specializations = await _specializationRepository.GetAllSpecializations();
      return View(specializations);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
      ViewBag.Categories = new SelectList(await _categoryRepository.GetAllAsync(), "Id", "Name");
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Specialization specialization)
    {
      await _specializationRepository.AddAsync(specialization);
      return RedirectToAction("Index", "AdminSpecialization");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
      var specialization = await _specializationRepository.GetByIdAsync(id);
      ViewBag.Categories = new SelectList(await _categoryRepository.GetAllAsync(), "Id", "Name");
      return View(specialization);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Specialization specialization)
    {
      await _specializationRepository.UpdateAsync(specialization);
      return RedirectToAction("Index", "AdminSpecialization");
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
      await _specializationRepository.DeleteAsync(id);
      return RedirectToAction("Index");
    }
  }
}