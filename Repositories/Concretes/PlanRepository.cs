using BusinessApp.Entities;
using BusinessApp.Repositories.Abstracts;
using BusinessApp.Repositories.Context;

namespace BusinessApp.Repositories.Concretes
{
    public class PlanRepository : Repository<Plan>, IPlanRepository
    {
        private readonly AppDbContext _context;
        public PlanRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}