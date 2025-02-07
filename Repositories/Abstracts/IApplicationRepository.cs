using BusinessApp.Entities;

namespace BusinessApp.Repositories.Abstracts
{
  public interface IApplicationRepository : IRepository<Application>
  {
    Task<bool> IsApplicationAsync(int userId, int jobId);
    Task<List<int>> GetAllUserAndJobAsync(int userId);
    Task<IEnumerable<Application>> GetAllApplicationsAsync(int userId);
  }
}