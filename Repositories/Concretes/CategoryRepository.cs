using BusinessApp.Entities;
using BusinessApp.Repositories.Abstracts;
using BusinessApp.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace BusinessApp.Repositories.Concretes
{
  public class CategoryRepository : Repository<Category>, ICategoryRepository
  {
    private readonly AppDbContext _context;

    public CategoryRepository(AppDbContext context) : base(context)
    {
      _context = context;
    }

    public async Task UpdateCategoryAsync(Category category)
    {
      var ctg = await GetByIdAsync(category.Id);
      ctg.Name = category.Name;
      _context.Categories.Update(ctg);
      await _context.SaveChangesAsync();
    }
  }
}