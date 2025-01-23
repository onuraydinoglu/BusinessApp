using BusinessApp.Entities;

namespace BusinessApp.Repositories.Abstracts
{
  public interface IUserRepository : IRepository<User>
  {
    Task UpdateUserAsync(User user);
  }
}