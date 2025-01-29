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
  public class AdminCategoriesController : Controller
  {
    private readonly ICategoryRepository _categoryRepository;

    public AdminCategoriesController(ICategoryRepository categoryRepository)
    {
      _categoryRepository = categoryRepository;
    }

    public async Task<IActionResult> Index()
    {
      var categories = await _categoryRepository.GetAllAsync();
      return View(categories);
    }


    [HttpGet]
    public async Task<IActionResult> Create()
    {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Category category)
    {
      await _categoryRepository.AddAsync(category);
      return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
      var category = await _categoryRepository.GetByIdAsync(id);
      return View(category);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Category category)
    {
      await _categoryRepository.UpdateCategoryAsync(category);
      return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
      await _categoryRepository.DeleteAsync(id);
      return RedirectToAction("Index");
    }

  }
}