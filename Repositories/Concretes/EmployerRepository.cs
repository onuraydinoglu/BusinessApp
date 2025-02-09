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

    public async Task<IEnumerable<Employer>> GetAllEmployersAsync()
    {
      var employers = await _context.Employers.Include(x => x.User).Include(x => x.Category).ToListAsync();
      return employers;
    }

    public async Task<List<Employer>> GetEmployersByUserIdAsync(int userId)
    {
      return await _context.Employers
          .Include(x => x.User)
          .Include(x => x.Category)
          .Where(x => x.UserId == userId)
          .ToListAsync();
    }



    public async Task<IEnumerable<Employer>> GetAllEmployersUserAsync(int userId)
    {
      var employer = await _context.Employers.Include(x => x.User).Include(x => x.Category).Where(x => x.UserId == userId).ToListAsync();
      return employer;
    }

    public async Task UpdateEmployerAsync(Employer employer)
    {
      var emp = await GetByIdAsync(employer.Id);
      emp.CompanyName = employer.CompanyName;
      emp.UserId = employer.UserId;
      emp.CategoryId = employer.CategoryId;
      emp.IsActive = employer.IsActive;
      _context.Employers.Update(emp);
      await _context.SaveChangesAsync();
    }
  }
}