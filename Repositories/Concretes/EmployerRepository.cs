using BusinessApp.Entities;
using BusinessApp.Repositories.Abstracts;
using BusinessApp.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace BusinessApp.Repositories.Concretes
{
  public class EmployerRepository : Repository<Employer>, IEmployerRepository
  {
    private readonly AppDbContext _context;

    public EmployerRepository(AppDbContext context) : base(context)
    {
      _context = context;
    }

    public async Task UpdateEmployerAsync(Employer employer)
    {
      var emp = await GetByIdAsync(employer.Id);
      emp.CompanyName = employer.CompanyName;
      emp.UserId = employer.UserId;
      emp.JobId = employer.JobId;
      _context.Employers.Update(emp);
      await _context.SaveChangesAsync();
    }
  }
}