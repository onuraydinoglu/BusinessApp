using BusinessApp.Entities;

namespace BusinessApp.Repositories.Abstracts
{
  public interface ISavedJobRepository : IRepository<SavedJob>
  {
    Task<IEnumerable<SavedJob>> GetAllSavedJobs(int userId);
    Task<bool> isSavedJobAsync(int userId, int jobId);
  }
}