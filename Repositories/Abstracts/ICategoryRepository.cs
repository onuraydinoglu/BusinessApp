using BusinessApp.Entities;

namespace BusinessApp.Repositories.Abstracts
{
  public interface ICategoryRepository : IRepository<Category>
  {
    Task UpdateCategoryAsync(Category category);
  }
}