using BusinessApp.Entities;

namespace BusinessApp.Repositories.Abstracts
{
  public interface IEmployerRepository : IRepository<Employer>
  {
    Task<IEnumerable<Employer>> GetAllEmployersAsync();
    Task<List<Employer>> GetEmployersByUserIdAsync(int userId);
    Task<IEnumerable<Employer>> GetAllEmployersUserAsync(int userId);
    Task UpdateEmployerAsync(Employer employer);
  }
}