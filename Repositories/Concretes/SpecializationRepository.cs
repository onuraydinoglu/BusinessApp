using BusinessApp.Entities;
using BusinessApp.Repositories.Abstracts;
using BusinessApp.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace BusinessApp.Repositories.Concretes
{
    public class SpecializationRepository : Repository<Specialization>, ISpecializationRepository
    {
        private readonly AppDbContext _context;

        public SpecializationRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Specialization>> GetAllSpecializations()
        {
            var specializations = await _context.Specializations.Include(x => x.Category).ToListAsync();
            return specializations;
        }

        public async Task UpdateSpecialization(Specialization specialization)
        {
            var spc = await GetByIdAsync(specialization.Id);
            spc.Name = specialization.Name;
            spc.CategoryId = specialization.CategoryId;
            spc.CreatedDate = specialization.CreatedDate;
            _context.Specializations.Update(specialization);
            await _context.SaveChangesAsync();
        }
    }
}