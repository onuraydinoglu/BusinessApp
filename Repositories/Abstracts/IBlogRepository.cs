using BusinessApp.Entities;

namespace BusinessApp.Repositories.Abstracts
{
  public interface IBlogRepository : IRepository<Blog>
  {

    Task<IEnumerable<Blog>> GetAllBlogsAsync();
    Task<Blog> GetByIdBlogAsync(int id);
    Task UpdateBlogAsync(Blog blog);
    Task<List<Blog>> GetAllUserAndBlogAsync(int userId);
  }
}