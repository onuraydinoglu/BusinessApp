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
    public class AdminBlogsController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IBlogRepository _blogRepository;
        private readonly IUserRepository _userRepository;

        public AdminBlogsController(ICategoryRepository categoryRepository, IBlogRepository blogRepository, IUserRepository userRepository)
        {
            _categoryRepository = categoryRepository;
            _blogRepository = blogRepository;
            _userRepository = userRepository;
        }

        public async Task<IActionResult> Index()
        {
            var blogs = await _blogRepository.GetAllBlogsAsync();
            return View(blogs);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = new SelectList(await _categoryRepository.GetAllAsync(), "Id", "Name");
            ViewBag.Users = new SelectList(await _userRepository.GetAllAsync(), "Id", "FullName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Blog blog)
        {
            await _blogRepository.AddAsync(blog);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Categories = new SelectList(await _categoryRepository.GetAllAsync(), "Id", "Name");
            ViewBag.Users = new SelectList(await _userRepository.GetAllAsync(), "Id", "FullName");
            var blog = await _blogRepository.GetByIdBlogAsync(id);
            return View(blog);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Blog blog)
        {
            await _blogRepository.UpdateBlogAsync(blog);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _blogRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }

    }
}