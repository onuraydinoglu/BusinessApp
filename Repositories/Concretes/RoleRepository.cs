using BusinessApp.Entities;
using BusinessApp.Repositories.Abstracts;
using BusinessApp.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace BusinessApp.Repositories.Concretes
{
  public class RoleRepository : Repository<Role>, IRoleRepository
  {
    private readonly AppDbContext _context;

    public RoleRepository(AppDbContext context) : base(context)
    {
      _context = context;
    }
  }
}