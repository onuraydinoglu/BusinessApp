using BusinessApp.Entities;

namespace BusinessApp.Repositories.Abstracts
{
  public interface IEmployerRepository : IRepository<Employer>
  {
    Task UpdateEmployerAsync(Employer employer);

  }
}