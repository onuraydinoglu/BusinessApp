using BusinessApp.Entities;
using BusinessApp.Repositories.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace BusinessApp.Controllers
{
  public class CategoriesController : Controller
  {
    private readonly ICategoryRepository _categoryRepository;

    public CategoriesController(ICategoryRepository categoryRepository)
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

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
      await _categoryRepository.DeleteAsync(id);
      return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
      var ctg = await _categoryRepository.GetByIdAsync(id);
      return View(ctg);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Category category)
    {
      await _categoryRepository.UpdateCategoryAsync(category);
      return RedirectToAction("Index");
    }
  }
}