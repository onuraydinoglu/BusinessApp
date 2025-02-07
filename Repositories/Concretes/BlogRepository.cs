using BusinessApp.Entities;
using BusinessApp.Repositories.Abstracts;
using BusinessApp.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace BusinessApp.Repositories.Concretes
{
  public class BlogRepository : Repository<Blog>, IBlogRepository
  {
    private readonly AppDbContext _context;

    public BlogRepository(AppDbContext context) : base(context)
    {
      _context = context;
    }

    public async Task<IEnumerable<Blog>> GetAllBlogsAsync()
    {
      var blogs = await _context.Blogs.Include(x => x.Category).Include(x => x.User).ToListAsync();
      return blogs;
    }

    public async Task<List<Blog>> GetAllUserAndBlogAsync(int userId)
    {
      var myBlogs = await _context.Blogs
          .Include(x => x.User)
          .Include(x => x.Category)
          .Where(x => x.UserId == userId)
          .ToListAsync();

      return myBlogs;
    }

    public async Task<Blog> GetByIdBlogAsync(int id)
    {
      var blog = await _context.Blogs.Include(x => x.Category).Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id);
      return blog;
    }

    public async Task UpdateBlogAsync(Blog blog)
    {
      var blg = await GetByIdAsync(blog.Id);
      blg.Title = blog.Title;
      blg.Description = blog.Description;
      blg.CreatedDate = blog.CreatedDate;
      blg.IsActive = blog.IsActive;
      blg.BlogImage = blog.BlogImage;
      blg.Url = blog.Url;
      blg.UserId = blog.UserId;
      blg.CategoryId = blog.CategoryId;
      _context.Blogs.Update(blg);
      await _context.SaveChangesAsync();
    }
  }
}