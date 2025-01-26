using BusinessApp.Entities;

namespace BusinessApp.Repositories.Abstracts
{
  public interface IJobRepository : IRepository<Job>
  {
    Task<IEnumerable<Job>> GetAllJobsAsync();
    Task<Job> GetByIdJobAsync(int? id);
    Task UpdateJobAsync(Job job);
    Task<List<string?>> GetAllLocationsAsync();

  }
}