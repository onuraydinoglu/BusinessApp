using System.Threading.Tasks;
using BusinessApp.Entities;
using BusinessApp.Models;
using BusinessApp.Repositories.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BusinessApp.Controllers
{
    public class BlogsController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IBlogRepository _blogRepository;
        private readonly IUserRepository _userRepository;

        public BlogsController(ICategoryRepository categoryRepository, IBlogRepository blogRepository, IUserRepository userRepository)
        {
            _categoryRepository = categoryRepository;
            _blogRepository = blogRepository;
            _userRepository = userRepository;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.Categories = new SelectList(await _categoryRepository.GetAllAsync(), "Id", "Name");
            ViewBag.Users = new SelectList(await _userRepository.GetAllAsync(), "Id", "FullName");
            var blogs = await _blogRepository.GetAllBlogsAsync();
            var modelView = new BlogViewModel
            {
                Blogs = blogs
            };
            return View(modelView);
        }

        public async Task<IActionResult> Details(int id)
        {
            var blog = await _blogRepository.GetByIdBlogAsync(id);
            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = new SelectList(await _categoryRepository.GetAllAsync(), "Id", "Name");
            ViewBag.Users = new SelectList(await _userRepository.GetAllAsync(), "Id", "FullName");

            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(Blog blog)
        {
            await _blogRepository.AddAsync(blog);
            return RedirectToAction("Index");
        }
    }
}