using BusinessApp.Entities;

namespace BusinessApp.Repositories.Abstracts
{
    public interface ISpecializationRepository : IRepository<Specialization>
    {
        Task<IEnumerable<Specialization>> GetAllSpecializations();
        Task UpdateSpecialization(Specialization specialization);
    }
}